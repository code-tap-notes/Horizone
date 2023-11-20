@extends('adminLayout')
@section('adminContent')
<div class="row">
    <hr/>
   <div class="col-lg-12">
   <section class="panel">
        <header class="panel-heading">
            <h2 class="title-list">@lang('dic.Ruling') </h2>
            <hr/>
            <h3 class="title-Add">@lang('dic.Edit') @lang('dic.Ruling')</h3>
           
        </header>
        @include('admin.message')
        <div class="panel-body">
            <div class="position-center">
                <form role="form" action="{{URL::to('/rulings/'.$ruling->id)}}" method="post" enctype="multipart/form-data">
                @method('PATCH')
                               
                
               @include('admin.Ruling.formEdit')
               
                <button type="submit" name = "updateRuling" class="btn btn-info">@lang('dic.Update') @lang('dic.Ruling')</button>
                <a href="{{URL::to('/rulings')}}" name = "return" class="btn btn-info">@lang('dic.Return')</a>

                @csrf 
            </form>
            </div>
        </div>
    </section>
</div>
</div>

@endsection